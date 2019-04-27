<template>
  <div class="NewsFeed container" id="mainContainer">
      <div class="container text-center mt-5" id="selectCategory">
          <input v-model="filtered" type="search" class="form-control" placeholder="Find by category">
      </div>
      <div class="row">
        <div v-for="item in filterNews" :key="item.Id" class="col-sm-6 col-md-4 col-lg-3" id="simpleColumn">
          <div class="card" style="width: 100%; height:100%;" id="simpleCard">
            <div class="imageInside">
              <img :src="item.Image" class="card-img-top" alt="" id="itemImage">
          </div>
          <div class="card-body" id="simpleCard">
          <h5 class="card-title">{{item.Title}}</h5>
          <p class="card-text">{{item.PublishDate}}</p>
          <a :href="item.Link" class="btn btn-outline-dark">Read more</a>
          </div>
         </div>
        </div>
      </div>
    </div>
</template>

<script>
export default {
  name: 'NewsFeed',

  data() {
    return {
      filtered:'',
      NewsFeed: [],
    }
  },

  methods: {
    fetchNewsFeed() {
        this.$http.get('http://localhost:52511/api/newsfeed')
        .then(response => response.json())
        .then(result => this.NewsFeed = result)
    },
  },

  computed: {
  filterNews () {
      const search = this.filtered.toLowerCase().trim();

      if (!search) return this.NewsFeed;

       return this.NewsFeed.filter(c => c.Category.toLowerCase().indexOf(search) > -1);
  }

  },

  created: function () {
    this.fetchNewsFeed();
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

#simpleCard:hover {
  background: gray;
}

#simpleColumn {
  padding: 10px;
  color:bisque;
  
}

.imageInside {

background-color: rgba(0,0,0,.4);
}

#itemImage {
  display: block;
  // margin-left: auto;
  // margin-right: auto;
  width: 100%;
  height: 100%;
}

#selectCategory {
  padding: 20px 0 20px 0;
}

#selectCategory select{
  border: 2px solid gray;
  width: 200px;
  height: 30px;
}

#simpleCard {
  text-align: center;
  background-color: rgba(0,0,0,.2);
} 

</style>
