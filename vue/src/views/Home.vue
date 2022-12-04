<template>
  <div class="home">
    <chat-box></chat-box>
    <input-message />
  </div>
</template>

<script>
import InputMessage from '../components/InputMessage.vue';
import ChatBox from '../components/ChatBox.vue';

export default {
  name: "home",
  components: { InputMessage, ChatBox },
};

</script>
