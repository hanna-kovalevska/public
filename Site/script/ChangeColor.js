var tables = document.getElementsByClassName("color_table");
var rows = [];
for (var i = 0; i < tables.length; i++)
{
  for (j = 0; j < tables[i].children[0].children.length; j++)
  {
    rows.push(tables[i].children[0].children[j]);
  }
}

for (i = 0; i < rows.length; i++)
{
  rows[i].setAttribute("onmouseover", "this.className = 'color_row'");
  rows[i].setAttribute("onmouseout", "this.className = ''");
}
