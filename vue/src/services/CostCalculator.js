let display;
let previous = null;
let operator = null;
let operatorClicked = false;


function performOperation() {
  let result;
  const current = parseNumber(display.value);
  previous = parseNumber(previous);

  switch(operator) {
    case '+' :
      result = previous + current;
    break;
    case '-' :
        result = previous - current;
    break;
    case '*' :
        result = previous * current;
    break;
    case '/' :
        result = previous / current;
    break;
  }

  display.value = result;
  operator = null;
}

//@param {String} num

function parseNumber(num) {
  return num.includes('.') ? parseFloat(num) : parseInt(num);
}

function clickOperator(event) {
  operator = event.target.value;
  previous = display.value;
  operatorClicked = true;
}

//@param {Event} event 
function clickNumber(event) {
  const val = event.target.value;

  if( operatorClicked ) {
    display.value = val;
    operatorClicked = false;
  } else {
    display.value == 0 ? display.value = val : display.value += val;
  }

}

function clear() {
  display.value = 0;
}

document.addEventListener('DOMContentLoaded', () => {

  display = document.querySelector("#display");

  let numberClicked = document.querySelectorAll(".number");
  for (let i = 0; i < numberClicked.length; i++) {
      numberClicked[i].addEventListener("click", (event) => {
          clickNumber(event);
      });
  }

  const decimal = document.querySelector(".decimal");
  decimal.addEventListener("click", (event) => {
      clickNumber(event);
  })

  const clearButton = document.querySelector(".all-clear");
  clearButton.addEventListener("click", (event) => { clear() });

  operatorAll = document.querySelectorAll(".operator")
  for (let i = 0; i < operatorAll.length; i++) {
      operatorAll[i].addEventListener("click", (event) => {
          clickOperator(event);
      })
  }

  const equal = document.querySelector("body > div > div > button.equal-sign");
  equal.addEventListener("click", (event) => { performOperation() });
});