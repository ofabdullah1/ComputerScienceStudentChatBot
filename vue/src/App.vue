<template>
  <div id="app">
    <div id="header">
      <img id="robot" src="https://img.freepik.com/premium-vector/cute-robot-waving-hand-cartoon-illustration_138676-2744.jpg?w=740" alt="Picture of a robot">
      <h1 class="title">Welcome to the TE Digital Assistant</h1>
      <div id="nav">
        <router-link class="button" v-bind:to="{name:'home'}">Home</router-link> 
           <router-link class="button" v-bind:to="{name:'about'}">Team</router-link>
        </div>
    </div>
    <router-view id="view" />
    <footer id="footer">Copyright &copy; 2022, Team Oscar</footer>
  </div>
</template>

<style>
@import url("https://fonts.googleapis.com/css?family=Audiowide");
#app {
  font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
  display: grid;
  grid-template-areas:
    "header"
    "chatbot"
    "footer";
  row-gap: 10px;
  column-gap: 10px;
  background-image: url("https://img.freepik.com/free-photo/motherboard-circuit-technology-background-gradient-blue_53876-124654.jpg?size=626&ext=jpg&ga=GA1.2.1987393692.1670518260");
  height: 100%;
  background-color: #7A7FB1;
  padding: 0px;
  margin: 0px;
}
#view {
  grid-area: chatbot;
  display: flex;
  justify-content: center;
  border: 5px solid transparent;
  height: 70vh;
  margin-left: 10px;
  margin-right: 10px;
}
#header {
  grid-area: header;
  display: flex;
  justify-content: space-between;
  height: auto;
  border: transparent;
  border-radius: 20px;
  background-color: #CEF0FD;
  margin-top: 10px;
  margin-left: 15px;
  margin-right: 15px;
}
.title {
  display: flex;
  align-items: center;
  font-family: "Audiowide", sans-serif;
  text-align: end;
  color: black;
}
#footer {
  grid-area: footer;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 20%;
}
#nav {
  grid-area: nav;
  display: flex;
}
.button {
  align-items: center;
  background-image: linear-gradient(144deg, #AF40FF, #5B42F3 50%, #00DDEB);
  border: 0;
  border-radius: 8px;
  box-shadow: rgba(151, 65, 252, 0.2) 0 15px 30px -5px;
  box-sizing: border-box;
  color: #FFFFFF;
  display: flex;
  font-family: Phantomsans, sans-serif;
  font-size: 20px;
  justify-content: center;
  line-height: 1em;
  max-width: 100%;
  min-width: 140px;
  padding: 10px 24px;
  text-decoration: none;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  white-space: nowrap;
  cursor: pointer;
  margin: 80px 30px 65px 20px;
  box-shadow: 5px 5px 5px black;
}
#robot {
  grid-area: robot;
  max-width: 200px;
  margin-left: 20px;
}
</style>
