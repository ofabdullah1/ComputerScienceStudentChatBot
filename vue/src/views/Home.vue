<template>
  <div class="home">
    <chat-box></chat-box>
    <quote />
    <help />
    <input-message />
  </div>
</template>

<script>
import InputMessage from "../components/InputMessage.vue";
import ChatBox from "../components/ChatBox.vue";
import Help from "../components/Help.vue";
import Quote from '../components/Quote.vue';

export default {
  name: "home",
  components: { InputMessage, ChatBox, Help, Quote },
};
</script>
