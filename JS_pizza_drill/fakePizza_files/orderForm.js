function getOrder() {
  text1 = "";
  text2 = "";
  var runningTotal = 0; // the running total as all elements are added up
  var sizeTotal = 0; // the total amount chosen from the sizeArray
  var sizeArray = document.getElementsByClassName("size"); // grabs all the elements with the class name "size" and puts them in an array
  for (var i = 0; i < sizeArray.length; i++) { //counting loop for the length of the array
    if (sizeArray[i].checked) { // looks for the value that is checked in the radio buttons
      var selectedSize = sizeArray[i].value; // assigns the value of the checked element to the variable "selectedSize"
      text1 = text1+selectedSize+"<br>" // adds the value of the selected size to the text1 running string
    }
  }
  if (selectedSize === "Personal Pizza") {
    sizeTotal = 6; //assigns a value of "6" if the checked radio is "Personal Pizza"
    text2 = text2+sizeTotal+".00"+"<br>"; // adds 6 to "sizeTotal"
  } else if (selectedSize === "Medium Pizza") {
    sizeTotal = 10; //assigns a value of "10" if the checked radio is "Medium Pizza"
    text2 = text2+sizeTotal+".00"+"<br>"; // adds 10 to "sizeTotal"
  } else if (selectedSize === "Large Pizza") {
    sizeTotal = 14; //assigns a value of "14" if the checked radio is "Large Pizza"
    text2 = text2+sizeTotal+".00"+"<br>"; // adds 14 to "sizeTotal"
  } else if (selectedSize === "Extra Large Pizza") {
    sizeTotal = 16; //assigns a value of "16" if the checked radio is "Extra Large Pizza"
    text2 = text2+sizeTotal+".00"+"<br>"; // adds 16 to "sizeTotal"
  }
  runningTotal = sizeTotal; // makes the running Total equal to Size total as the first step
  getMeat(runningTotal,text1,text2); // places the variables of runningTotal, text1 and text2 into getMeat
};


function getMeat(runningTotal,text1,text2) {
  var runningTotal = runningTotal; // keeps the running total as it was passed from getOrder
  var meatTotal = 0; // the total value of the items chosen from the meatArray
  var selectedMeat = [];
  var meatArray = document.getElementsByClassName("meat"); // grabs all the elements with the class name "meat" and puts them in an array
  for (var j = 0; j < meatArray.length; j++){ //counting loop for the length of the array
    if (meatArray[j].checked) {
      selectedMeat.push(meatArray[j].value); // if an element in meatArray is checked, then push the value of that element to selectedMeat
    }
  }
  var meatCount = selectedMeat.length; // the number in meatCount is equal to the number of items pushed to selectedMeat
  if (meatCount > 1) {
    meatTotal = (meatCount - 1); // because the first meat is free, we need to remove one from the count over 1 selection
  } else {
    meatTotal = 0; // if meatCount is 1 or less, the total is 0
  }
  runningTotal = (runningTotal + meatTotal); // adding the meat total to the running total
  for (var j = 0; j < selectedMeat.length; j++) {
    text1 = text1+selectedMeat[j]+"<br>";
    if (meatCount <= 1) {
      text2 = text2 + 0 + ".00"+ "<br>";
      meatCount = meatCount - 1;
  /*  } else if (meatCount == 2) { // not sure why this is needed. Seems like the "else" statement takes care of it
      text2 = text2 + 1 + "<br>";
      meatCount = meatCount - 1; */
    } else {
      text2 = text2 + 1 + ".00" + "<br>";
      meatCount = meatCount - 1;
    }
  }
  getVeggie(runningTotal,text1,text2); // passing the running total, text1 and text2 variables into getVeggie
};

function getVeggie(runningTotal,text1,text2) { // this is essentially the same as getMeat
  var veggieTotal = 0;
  var selectedVeggie = [];
  var veggieArray = document.getElementsByClassName("veggies");
  for (var j = 0; j < veggieArray.length; j++) {
    if (veggieArray[j].checked) {
      selectedVeggie.push(veggieArray[j].value);
    }
  }
  var veggieCount = selectedVeggie.length;
  if (veggieCount > 1) {
    veggieTotal = (veggieCount - 1);
  } else {
    veggieTotal = 0;
  }
  runningTotal = (runningTotal + veggieTotal);
  for (var j = 0; j < selectedVeggie.length; j++) {
    text1 = text1+selectedVeggie[j]+"<br>";
    if (veggieCount <= 1) {
      text2 = text2 + 0 + ".00" + "<br>";
      veggieCount = veggieCount - 1;
    } else {
      text2 = text2 + 1 + ".00" + "<br>";
      veggieCount = veggieCount - 1;
    }
  }
  getCheese(runningTotal,text1,text2);
};

function getCheese(runningTotal,text1,text2) {
  var cheeseTotal = 0;
  var selectedCheese = [];
  var cheeseArray = document.getElementsByClassName("cheese");
  for (var j = 0; j < cheeseArray.length; j++) {
    if (cheeseArray[j].checked) {
      selectedCheese = cheeseArray[j].value;
    }
    if (selectedCheese === "Extra cheese") {
      cheeseTotal = 3;
    }
  }
  text2 = text2+cheeseTotal+".00"+"<br>";
  text1 = text1+selectedCheese+"<br>";
  runningTotal = (runningTotal + cheeseTotal);
  getSauce(runningTotal,text1,text2);
};

function getSauce(runningTotal,text1,text2) {
  var sauceArray = document.getElementsByClassName("sauce");
  for (var j = 0; j < sauceArray.length; j++) {
    if (sauceArray[j].checked) {
      selectedSauce = sauceArray[j].value;
      text1 = text1 + selectedSauce + "<br>";
    }
  }
  text2 = text2 + 0 + ".00" + "<br>"; // all sauces are included, so we do not need to add any numbers to the running total
  getCrust(runningTotal,text1,text2);
};

function getCrust(runningTotal,text1,text2) {
  var crustTotal = 0;
  var selectedCrust = [];
  var crustArray = document.getElementsByClassName("crust");
  for (var j = 0; j < crustArray.length; j++) {
    if (crustArray[j].checked) {
      selectedCrust = crustArray[j].value;
      text1 = text1 + selectedCrust + "<br>"
    }
    if (selectedCrust === "Cheese Stuffed Crust") {
      crustTotal = 3;
    }
  }
  runningTotal = (runningTotal + crustTotal);
  text2 = text2 + crustTotal + ".00" + "<br>";
  document.getElementById("cart").style.opacity=1; // makes the cart box visible
  document.getElementById("showText1").innerHTML=text1; // places the names of the ordered elements in the order box
  document.getElementById("showText2").innerHTML=text2; // displays the total addition for the extra options
  document.getElementById("totalPrice2").innerHTML = "<h3>$"+runningTotal+".00"+"</h3>";
};

function clearCart() { // clears the order form
  document.getElementById("frmMenu").reset(); // resets the form options
  document.getElementById("cart").style.opacity=0; // hides the cart
}
