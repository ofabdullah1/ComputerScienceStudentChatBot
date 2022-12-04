<template>
  <div>
      <form>
          <label for="message">Message: </label>
          <input type="text" id="message" v-model="userMessage">
          <button type="submit" v-on:click.prevent="saveMessage" class="send">Send</button>
      </form>
  </div>
</template>

<script>
export default {
    name: "input-message",
    data: () => {
        return {
            userMessage: ""
        }
    },
    methods: {
        saveMessage() {
            console.log("Reached saveMessage in Home.vue");
            this.$store.commit("SAVE_MESSAGE", this.userMessage);
            this.userMessage = "";
        }
    }
}
</script>

<style>

</style>