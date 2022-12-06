<template>
  <div>
    <p id="message">{{ message }}</p>
    <h2>{{ quote.message }}</h2>
    <h3>{{ quote.author }}</h3>
  </div>
</template>

<script>
import QuoteService from "../services/QuoteService";
export default {
  data: () => {
    return {
      quote: {},
      message: "",
    };
  },

  methods: {
    getRandomIndex() {
      let index = Math.floor(Math.random() * this.$store.state.quotes.length);

      return index;
    },
    getOneQuote() {
      let index = this.getRandomIndex();
      this.quote = this.$store.state.quotes.find((q) => {
        return q == this.$store.state.quotes[index];
      });
    },
  },

  created() {
    this.message = "";
    QuoteService.getQuotes()
      .then((response) => {
        this.$store.commit("DISPLAY_QUOTES", response.data);
        this.getOneQuote()
      })
      .catch((error) => {
        if (error.response) {
          this.message =
            "Error: HTTP Response Code: " + error.response.data.status;
          this.message += "  Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
  },
};
</script>

<style>
</style>