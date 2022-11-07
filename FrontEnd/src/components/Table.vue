<template>
  <div class="container text-center">
    <h1>To Do List</h1>
    <hr/>
    <div class="table-responsive">
      <table class="table">
        <thead>
          <tr>
            <th style="color: gray;">Description</th>
            <th style="color: gray;">Created</th>
            <th style="color: gray;">Expires</th>
            <th style="color: gray;">Status</th>
            <th style="color: gray;">Action</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(todo, index) in todos" :key="index">
            <td style="color: antiquewhite;">
              <router-link :to='`/todo/${todo.id}`'>{{ todo.description }}</router-link></td>
            <td style="color: antiquewhite;">{{ todo.created }}</td>
            <td style="color: antiquewhite;">{{ todo.expires }}</td>
            <td style="color: antiquewhite;">{{ parseStatus(todo.status) }}</td>
            <td style="color: red;">
              <button class="btn btn-danger" @click=deleteItem(todo.id)>
                Delete
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <br />
    <div class="row justify-content-start">
      <div class="col-md-auto">
        <router-link to="/todo" >Add New</router-link>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import { format, parseISO } from 'date-fns';

const inputDateFormat = 'yyyy-MM-dd';

export default {
  async created() {
    try{
      const response = await axios.get(`https://localhost:7153/api/todos`);
      this.todos = response.data.map(t=>{
        t.created = format(parseISO(t.created),inputDateFormat);
        t.expires = format(parseISO(t.expires),inputDateFormat);
        return t;
      });
    }
    catch(error){
      alert(error);
    }
  },
  data() {
    return {
      todos: {},
    }
  },
  methods: {
    async deleteItem(id) {
      await axios.delete(`https://localhost:7153/api/todos/${id}`)
                    .then(() => {
                        alert("To Do Deleted");
                        this.$router.go();
                    })
                    .catch(error => alert(error));
    },
    parseStatus(status) {
      switch (status) {
        case 0:
          return 'To Do';
        case 1:
          return 'In Progress';
        case 2:
          return 'Done';
        case 3:
          return 'Expired';
        default:
          return 'Unknown';

      }

    }
  },
}
</script>

<style>

</style>