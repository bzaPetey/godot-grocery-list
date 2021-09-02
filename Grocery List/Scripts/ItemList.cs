/*
ItemList.gd
Peter Laliberte

A simple project to learn some C# using the godot engine.
This is a simple grocery list app that will allow the use to add/remove items from a list.
I am using the ItemList in godot instead of a collection in C#.

ItemList Docs: https://godot-es-docs.readthedocs.io/en/latest/classes/class_itemlist.html

TODO:
Alphabetize list
Save data to system
Dynamically Adjust to screen resolution
Export to Andriod
*/
using Godot;
using System;

public class ItemList : Godot.ItemList
{
    private LineEdit le;



    public override void _Ready()
    {
        le = GetNode("../ItemEntry") as LineEdit;
        le.ClearButtonEnabled = true;
    }



    public void OnAddItemButtonPressed() {
        if (String.IsNullOrWhiteSpace(le.Text)) {
            le.Clear();
            return;
        }

        for(int cnt = 0; cnt < this.GetItemCount(); cnt++) {
            if(le.Text.ToLower() == this.GetItemText(cnt)) {
                le.Clear();
                return;
            }
        }

        this.AddItem(le.Text.ToLower());
        le.Clear();
  }



  public void OnRemoveItemButtonPressed() {
    if(!this.IsAnythingSelected())
        return;

    for(int cnt = 0; cnt < this.GetItemCount(); cnt++) {
        if(this.IsSelected(cnt)) {
            this.RemoveItem(cnt);
            return;
        }
    }
  }
}
