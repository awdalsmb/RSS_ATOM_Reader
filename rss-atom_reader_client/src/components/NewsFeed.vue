<template>
  <div class="NewsFeed">
    <h1>{{msg}}</h1>
  </div>
</template>

<script>
export default {
  name: 'NewsFeed',

  data() {
    return {
      msg: 'First template',
    }
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
</style>
