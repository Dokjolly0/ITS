const bottone = document.querySelector("button");
const arr = [
  document.querySelector("#img1"),
  document.querySelector("#img2"),
  document.querySelector("#img3"),
  document.querySelector("#img4"),
  document.querySelector("#img5"),
  document.querySelector("#img6"),
];
bottone.addEventListener("click", function () {
  arr.forEach(function (item) {
    item.classList.remove("show");
  });
  let random = Math.floor(Math.random() * arr.length);
  arr[random].classList.add("show");
});
