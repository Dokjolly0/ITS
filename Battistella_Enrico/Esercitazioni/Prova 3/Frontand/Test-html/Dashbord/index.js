const dropdown = document.querySelector(".dropdown");
const userIcon = document.getElementById("userIcon");

userIcon.addEventListener("click", function () {
  if (dropdown) dropdown.classList.toggle("show");
  if (dropdown.classList.contains("show")) {
    userIcon.style.right = "-100px";
    // userIcon.classList.add("sliderUser");
    // userIcon.classList.remove("sliderUserReverse");
  } else {
    // userIcon.classList.add("sliderUserReverse");
    // userIcon.classList.remove("sliderUser");
    userIcon.style.right = "60px";
  }
});
