<template>
  <div class="chat-box-container">
    <div class="top-box" ref="chatbox">
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
            <span v-html="message.text">{{ message.text }}</span>
          </p>
        </li>
      </ul>
    </div>
    <div id="textbox">
      <input
        type="text"
        v-model="userMessage"
        v-on:keyup.enter="sendMessage"
        class="chat-input"
      />
      <button v-on:click="sendMessage" class="send-button">Send</button>
    </div>
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
      });
      const bodyMessage = {
        Message: this.userMessage,
        context: this.$store.state.context,
      };

      MessageService.sendMessage(bodyMessage).then((response) => {
        const serverMessage = response.data;
        this.$store.commit("UPDATE_CONTEXT", serverMessage.context);
        this.messages.push({
          text: response.data.message,
          author: "server",
        });
        this.$nextTick(() => {
          this.$refs.chatbox.scrollTop = this.$refs.chatbox.scrollHeight;
        });
      });
      this.userMessage = "";
    },
  },
};
</script>

<style>
.top-box {
  overflow: scroll;
  overflow-x: hidden;
  overflow-y: inherit;
}
.chat-box-container {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: 80%;
  height: 100%;
  background: #cef0fd;
  border-radius: 20px;
}
.server {
  display: flex;
  flex-direction: column;
  justify-content: left;
  background-color: #0495d7;
  padding: 10px;
  max-width: 30%;
  border-radius: 40px;
  margin-left: 20px;
  margin-top: 20px;
  color: #fff;
  border-style: solid;
  border-color: black;
  box-shadow: 5px 5px 5px black;
  text-align: center;
  height: auto;
}
.client {
  background-color: #5b42f3;
  border-radius: 40px;
  width: 25%;
  margin-top: 20px;
  padding: 10px;
  position: relative;
  left: 71%;
  list-style-type: none;
  border-style: solid;
  border-color: black;
  box-shadow: 5px 5px 5px black;
  text-align: center;
  height: auto;
}

.chat-box-list {
  padding: 0px;
}
.client > p {
  text-align: center;
  height: auto;
  margin: 0 auto;
  width: 90%;
  color: #fff;
}
#textbox {
  grid-area: input;
  text-align: center;
  width: 100%;
  margin-bottom: 15px;
}
.chat-input {
  padding: 3px;
  width: 40%;
  border-radius: 40px;
  border: transparent;
}
.send-button {
  background-image: linear-gradient(144deg, #af40ff, #5b42f3 50%, #00ddeb);
  border: transparent;
  border-radius: 40px;
  color: #ffffff;
  padding: 5px;
}
li {
  list-style-type: none;
}
</style>