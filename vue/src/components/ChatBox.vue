<template>
  <div class="chat-box-container">
    <div class="server">
      <p>Hi! My name is TE Bot.</p>
      <p>What's your name?</p>
    </div>
    <ul class="chat-box-list">
      <li
        v-for="(message, index) in messages"
        v-bind:key="index"
        :class="message.author"
      >
        <p>
          <span>{{ message.text }}</span>
        </p>
      </li>
    </ul>
    <input
      type="text"
      v-model="userMessage"
      v-on:keyup.enter="sendMessage"
      class="chat-input"
    />
    <button v-on:click="sendMessage" class="send-button">Send</button>
  </div>
</template>

<script>
import MessageService from "../services/MessageService.js";

export default {
  name: "chat-box",
  data: () => {
    return {
      messages: [],
      userMessage: "",
    };
  },
  methods: {
    sendMessage() {
      this.messages.push({
        text: this.userMessage,
        author: "client",
      })
      const bodyMessage = {Message: this.userMessage,
      Context: ""}
      MessageService.sendMessage(bodyMessage)
      .then((response) => {
        this.messages.push({
          text: response.data,
          author: "server",
        });
      });
      //MessageService.receiveMessage()
      this.userMessage = ""
    },
  },
};
</script>

<style>
</style>