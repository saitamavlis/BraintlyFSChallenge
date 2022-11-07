<template>
    <div class="container text-center">
        <div class="row">
            <h1>ToDo Form</h1>
        </div>
        <hr />
        <div class="row">
            <div class="">
                <form @submit.prevent="addTodo">
                    <div class="mb-3">
                        <label for="description" class="form-label"><strong>Description:</strong></label>
                        <input id="description" class="form-control" type="text" placeholder='Description' required
                            v-model="todo.description" />
                    </div>
                    <div class="mb-3" v-show="!!id">
                        <label for="created" class="form-label"><strong>Created:</strong></label>
                        <input id="created" class="form-control" type="date" v-model="todo.created" disabled />
                    </div>
                    <div class="mb-3">
                        <label for="expires" class="form-label"><strong>Expires:</strong></label>
                        <input id="expires" class="form-control" type="date" v-model="todo.expires" required/>
                    </div>
                    <div class="mb-3" v-show="!!id">
                        <label for="todoStatus" class="form-label"><strong>Status:</strong></label>
                        <select class="form-select" id="todoStatus" v-model="todo.status">
                            <option selected>Choose Status</option>
                            <option value=0>To Do</option>
                            <option value=1>In Progress</option>
                            <option value=2>Done</option>
                            <option value=3>Expired</option>
                        </select>
                    </div>
                    <div class="row justify-content-end">
                        <div class="col-md-auto">
                            <button type="submit" class="btn btn-primary " v-if="todo.status !== 3">Save</button>
                        </div>
                        <div class="col-md-auto" v-show="!!id">
                            <button class="btn btn-danger" @click="onDeleteClick">Delete</button>
                        </div>
                    </div>
                    <br />
                    <div class="row justify-content-start">
                        <div class="col-md-auto">
                            <router-link to='/todos'>Return</router-link>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import { format, parseISO } from 'date-fns';

const inputDateFormat = 'yyyy-MM-dd';

export default {
    data() {
        return {
            id: this.$route.params.id,
            todo: {
                id: '',
                description: '',
                created: '',
                expires: '',
                status: 0
            }
        }
    },
    methods: {
        async addTodo() {
            if (this.id) {
                console.log(this.todo);
                const todoDto = {
                    description: this.todo.description,
                    expires: this.todo.expires,
                    status: parseInt(this.todo.status)
                }
                await axios.put(`https://localhost:7153/api/todos/${this.id}`, todoDto)
                    .then(() => {
                        alert("To Do Modified");
                        this.$router.push('/');
                    })
                    .catch(error => alert(error));
            }
            else {
                await axios.post(`https://localhost:7153/api/todos`, this.todo)
                    .then(() => {
                        alert("To Do Created");
                        this.$router.push('/');
                    })
                    .catch(error => alert(error));
            }
        },
        async onDeleteClick() {
            await axios.delete(`https://localhost:7153/api/todos/${this.id}`)
                    .then(() => {
                        alert("To Do Deleted");
                        this.$router.push('/');
                    })
                    .catch(error => alert(error));
        },
        

    },
    async created() {
        if (this.id) {
            const response = await axios.get(`https://localhost:7153/api/todos/${this.id}`);
            this.todo = response.data;
            this.todo.created=format(parseISO(this.todo.created),inputDateFormat);
            this.todo.expires=format(parseISO(this.todo.expires),inputDateFormat);
        }
    }
}
</script>

<style>

</style>