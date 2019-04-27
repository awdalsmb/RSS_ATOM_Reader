<template>
  <div id="app">
    <!-- <div id="nav">
      <router-link to="/">News</router-link>
    </div> -->
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'app',
};

</script>

<style lang="scss">
#app {
    background: url('../src/assets/background.jpg') no-repeat;
    background-size:cover;

}
</style>
