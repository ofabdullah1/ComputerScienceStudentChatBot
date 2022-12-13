<template>
  <div>
    <div id="team-body">
      <h1 class="team-title">The Team</h1>
      <div class="team-headshots">
        <div class="person">
        <img id="headshot" src="https://ca.slack-edge.com/T0GNFLF6D-U03SCRLCK6K-3c6e69476d55-512" alt="Keiko">
        <a href="https://www.linkedin.com/in/keikosjostrom/" target="_blank">Keiko Sjostrom</a>
        </div>
        <div class="person">
        <img id="headshot" src="https://ca.slack-edge.com/T0GNFLF6D-U03SLQDJ64W-dfe69015d08a-512" alt="Omar">
        <a href="https://www.linkedin.com/in/ofabdullah1/" target="_blank">Omar Abdullah</a>
        </div>
        <div class="person">
        <img id="headshot" src="https://ca.slack-edge.com/T0GNFLF6D-U03T62ATR0R-dbbabe093f1c-512" alt="Kate">
        <a href="https://www.linkedin.com/in/kate-karpenkova/" target="_blank">Ekaterina Karpenkova</a>
        </div>
        <div class="person">
        <img id="headshot" src="https://ca.slack-edge.com/T0GNFLF6D-U03STADP11R-69aa13899cb2-512" alt="Parker">
        <a href="https://www.linkedin.com/in/parker-crook/" target="_blank">Parker Crook</a>
        </div>
      </div>
     </div>
  </div>
</template>

<script>
export default {

}
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Audiowide");
#team-body {
  display: flex;
  flex-direction: column;
  align-items: center;
  height: auto;
  width: 96vw;
  border: transparent;
  border-radius: 20px;
  background-color: #CEF0FD;
  margin-top: 10px;
  margin-left: 15px;
  margin-right: 15px;
}
.team-title {
  display: flex;
  font-family: "Audiowide", sans-serif;
  text-align: end;
  color: black;
}
.team-headshots {
  display: flex;
  margin-right: 15px;
  margin-left: 15px;
}
#headshot {
  max-width: 90%;
  border-style: solid;
}
.team-names {
  display: flex;
  justify-content: space-between;
  font-family: "Audiowide", sans-serif;
  color: black;
}
.person {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  font-family: "Audiowide", sans-serif;
  color: black;
}
a {
  text-decoration: none;
  margin-top: 20px;
  color: black;
  font-size: 25px;
}

</style>