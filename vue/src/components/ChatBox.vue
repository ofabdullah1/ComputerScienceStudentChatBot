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
          <span v-html = "message.text" >{{ message.text }}</span>
        </p>
      </li>
    </ul>
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
      })
      const bodyMessage = {Message: this.userMessage,
      context: this.$store.state.context}

      MessageService.sendMessage(bodyMessage)
      .then((response) => {
        const serverMessage = response.data;
        this.$store.commit("UPDATE_CONTEXT",serverMessage.context);
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
.chat-box-container {
  overflow: scroll;
  height: 71vh;
  overflow-x: hidden;
  overflow-y: inherit;
   background:#CEF0FD ;
   border-radius: 20px;
}
.server {
  display: flex;
  flex-direction: column;
  justify-content: left;
  height: max-content;
  background-color: #0495D7 ;
  padding: 10px;
  max-width: 15%;
  border-radius: 40px;
  margin-left: 20px;
  margin-top: 20px;
  inline-size: max-content;
   color: #fff;
   border-style: solid;
   border-color: black;
}
.client {
  background-color:#5B42F3;
  border-radius: 40px;
  width: 18%;
  margin-top: 20px;
  padding: 10px;
  position: relative;
  left: 80%;
  list-style-type: none;
     border-style: solid;
   border-color: black;
}
.chat-box-list > li {
  text-align: center;
  height: auto;
}
.chat-box-list{
  padding: 0px;
}
.client > p {
  overflow: scroll;
  overflow-x: hidden;
  overflow-y: hidden;
  margin: 0 auto;
  width: 90%;
   color: #fff;
}
#textbox {
  text-align: center;
  position: absolute;
  width: 100%;
  bottom: 50px;
  margin-bottom: 15px;
}
.chat-input {
  position: -webkit-sticky;
  position: sticky;
  padding: 3px;
  width: 500px;
  border-radius: 40px;
  border: transparent;
}
.send-button {
  background-image: linear-gradient(144deg, #AF40FF, #5B42F3 50%, #00DDEB);
  border: transparent;
  border-radius: 40px;
  color: #FFFFFF;
  padding: 5px;
}
</style>