var containers = document.getElementsByClassName("carousel-container");
for (var i = 0; i < containers.length; i++)
{
  var container = containers[i];
  var X = container.offsetLeft;
  var Y = container.offsetTop;

  var containerChildren = container.children;
  var previews = [];
  for (let i = 0; i < containerChildren.length; i++)
  {
    if (containerChildren[i].className == "preview")
    {
      previews.push(containerChildren[i]);
    }
  }
  var countPreviews = previews.length;
  var width = parseInt(window.getComputedStyle(container).getPropertyValue("width"));

  var visibleCount = 0;
  while (((visibleCount + 1) * 100) <= width)
  {
    visibleCount++;
  }

  // Position previews
  for (let i = 0; i < countPreviews; i++)
  {
    previews[i].style.left = (100 * i + 1) + "px";
    if (i >= visibleCount)
    {
      previews[i].style.visibility = "hidden";
    }
  }
  var firstX = previews[0].offsetLeft;
  var lastX = X + 100 * (countPreviews - 1);

  var leftButton, rightButton;
  for (let i = 0; i < containerChildren.length; i++)
  {
    if (containerChildren[i].className == "button-left")
    {
      leftButton = containerChildren[i];
      break;
    }
  }
  for (let i = 0; i < containerChildren.length; i++)
  {
    if (containerChildren[i].className == "button-right")
    {
      rightButton = containerChildren[i];
      break;
    }
  }

  if (lastX + 100 < width)
  {
    leftButton.style.display = "none";
    rightButton.style.display = "none";
  }

  rightButton.style.left = (width - 50) + "px";

  // Move elements to the left + Handle overflow
  var offset = 0;
  leftButton.onclick = function()
  {
    previews[offset].style.visibility = "hidden";
    for (let i = 0; i < countPreviews; i++)
    {
      previews[i].style.left = (previews[i].offsetLeft - 100) + "px";
    }

    previews[mod((visibleCount + offset), countPreviews)].style.visibility = "visible";
    previews[offset].style.left = lastX + "px";

    offset++;
    offset = mod(offset, countPreviews);
  }

  // Move elements to the right + Handle overflow
  rightButton.onclick = function()
  {
    previews[mod((visibleCount + offset - 1), countPreviews)].style.visibility = "hidden";
    for (let i = 0; i < countPreviews; i++)
    {
      previews[i].style.left = (previews[i].offsetLeft + 100) + "px";
    }

    previews[mod((countPreviews + offset - 1), countPreviews)].style.left = 0 + "px";
    previews[mod((countPreviews + offset - 1), countPreviews)].style.visibility = "visible";

    offset--;
    offset = mod(offset, countPreviews);
  }
}

function mod(x, y)
{
  return x - y * Math.floor(x / y);
}