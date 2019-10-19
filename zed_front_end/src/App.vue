<template>
  <div id="app">
    <b-row>
      <b-col md="6" offset-md="3">
        <Header />
        <br>
        <Study />
      </b-col>
    </b-row>
  </div>
</template>

<script>
import Study from "./components/Study.vue";
import Header from "./components/Header.vue";

export default {
  name: "app",
  components: {
    Study,
    Header
  }
};
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
