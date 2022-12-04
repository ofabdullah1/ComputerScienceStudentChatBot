<template>
  <div id="app">
    <div id="header">
      <h1>Welcome to the TE Digital Assistant</h1>
      <div id="nav">
        <router-link v-bind:to="{name:'home'}">Home</router-link> |
           <router-link v-bind:to="{name:'about'}">About</router-link>
        </div>
    </div>
    <router-view />
    <footer>Copyright &copy; 2022, Team Oscar</footer>
  </div>
</template>
