function show(elementId)
{
    var element = document.getElementById(elementId);
    element.classList.add("display-content");
}

function hide(elementId)
{
    var element = document.getElementById(elementId);
    element.classList.remove("display-content");
}
