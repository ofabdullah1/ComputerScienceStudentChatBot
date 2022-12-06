<template>
  <div class="help" v-if="this.$store.state.message == 'help'">
    <p>Ok, Here are some ways you can phrase your questions:</p>
    <ul>
      <li>I need help with X</li>
      <li>Where can I learn about X</li>
      <li>I don’t understand X</li>
      <li>What is X</li>
    </ul>
    <p>
      or you can try using words or phrases. <br />
      What can I help you with today?
    </p>
    <ul>
      <li>Curriculum</li>
      <li>Pathway</li>
      <li>Motivation</li>
      <li>Positions</li>
      <li>I'm not sure</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "help",
};
</script>

<style>
</style>