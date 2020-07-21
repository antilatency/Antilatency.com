
function Spinbox(value, id, onChangeCallback) {
    var self = this;
    this.container = document.createElement("div");
    this.buttonDown = this.container.appendChild(document.createElement("div"));
    this.input = this.container.appendChild(document.createElement("input"));
    this.buttonUp = this.container.appendChild(document.createElement("div"));

    this.container.className = "Spinbox";
    this.buttonDown.className = "SpinboxButtonDown";
    this.input.className = "SpinboxInput";
    this.buttonUp.className = "SpinboxButtonUp";

    this.input.type = "text";
    this.input.id = id;
    this.input.value = value;

    SetInputFilter(this.input, (v) => /^\d+$/.test(v));

    this.input.onchange = function () {
        let value = Number(self.input.value);

        if (value == 0) {
            value = 1;
            self.input.value = value;
        }

        if (onChangeCallback) {
            onChangeCallback(value);
        }
    }

    this.buttonUp.onclick = function () {
        self.input.value = parseInt(self.input.value, 10) + 1;
        self.input.onchange();
    }

    this.buttonDown.onclick = function () {
        self.input.value = Math.max(parseInt(self.input.value, 10) - 1, 1);
        self.input.onchange();
    }
}

function SetInputFilter(textbox, inputFilter) {
    ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
        textbox.addEventListener(event, function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    });
}