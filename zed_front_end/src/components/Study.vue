<template>
  <div id="study-container">
    <b-container class="bv-example-row">
      <b-row>
        <b-col cols="4">
          <b-form-input
            v-model="guid"
            @keyup.enter="getStudy(guid)"
            required
            placeholder="Enter Guid to search study"
          ></b-form-input>

          <div class="text-left">
            <b-button
              class="custom-btn"
              variant="outline-primary"
              required
              :disabled="!guid"
              @click.prevent="getStudy(guid)"
            >Search</b-button>
          </div>
          
        </b-col>

        <b-col cols="8">

          <div class="alert alert-danger" role="alert" v-if="msg">
            <h4 class="alert-heading">Error!</h4>
            <hr />
            {{msg}}
          </div>

          <div>
            <b-table v-if="study.length>0" striped hover :items="study" :fields="fields"></b-table>
          </div>

        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      fields: ["key", "data"],
      study: [],
      msg: null,
      guid: ""
    };
  },
  methods: {
    getStudy(index) {
      console.log(index);
      var testURL = "https://localhost:44364/api/StudyContents/" + index;
      axios
        .get(testURL, {
          mode: "no-cors"
        })
        .then(response => {
          var result = Object.keys(response.data).map(name => {
            return { key: name, data: response.data[name] };
          });
          this.msg = null;
          this.study = result;
          console.log(result);
        })
        .catch(e => {
          this.study = [];
          this.msg = e;
          console.log(e);
        });
    }
  }
};
</script>

<style scoped>
.custom-btn {
  margin-top: 15px;
}
</style>