function OpenModal(imageId, containerId)
{
  var modal = document.getElementById(containerId);
  var img = document.getElementById(imageId);
  var modalImg = document.querySelector(`#${containerId} .modal-content`);
  var caption = document.querySelector(`#${containerId} .caption`);

  modal.style.display = "block";
  modalImg.src = img.src;
  caption.innerHTML = img.alt;

  var bodyEl = document.getElementsByTagName("body")[0];
  bodyEl.style.setProperty("overflow", "hidden");

  var close = document.querySelector(`#${containerId} .close`);
  close.onclick = function()
  {
    modal.style.display = "none";
    bodyEl.style.setProperty("overflow", "auto");
  }
}