<template>
  <div>
    <form>
      <label for="message">Message: </label>
      <input type="text" id="message" v-model="userMessage" />
      <button type="submit" v-on:click.prevent="saveMessage" class="send">
        Send
      </button>
    </form>
  </div>
</template>

<script>
import MessageService from '../services/MessageService'

export default {
  name: "input-message",
  data: () => {
    return {
      userMessage: "",
     
    };
  },
  methods: {
    saveMessage() {
      if (this.$store.state.message) {
        MessageService.sendMessage();
      }
      else {
       this.$store.commit("SAVE_MESSAGE", this.userMessage);
      }
    },
  },
};
</script>

<style>
</style>