<template>
  <div>
    <div class="greet1">
      <p>Hi! My name is TE Bot.</p>
      <p>What's your name?</p>
    </div>
    <div class="greet2" v-if="this.$store.state.message != ''">
      <p>
        Hello {{ this.$store.state.message }}! I’m TE-bot and I’m here to help
        you with your Tech Elevator needs. What can I help you with today?
      </p>
      <ul>
        <li>Curriculum</li>
        <li>Pathway</li>
        <li>Motivation</li>
        <li>Positions</li>
        <li>I'm not sure</li>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: "chat-box",
};
</script>

<style>
</style>