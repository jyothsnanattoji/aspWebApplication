console.log("Connected");

function checkIfNumber(input) {
    const regex = /^[0-9]*$/;
    if (!regex.test(input)) {
        return "Invalid input! Please enter a valid number for " + input +".\n";
    }
    return "";
}

function required() {
    var id = document.getElementById("Id").value;
    var firstName = document.getElementById("FirstName").value;
    var lastName = document.getElementById("LastName").value;
    var address = document.getElementById("Address").value;
    var dob = document.getElementById("Dob").value;
    var fatherName = document.getElementById("FatherName").value;
    var motherName = document.getElementById("MotherName").value;
    var mobile = document.getElementById("Mobile").value;
    var marks = document.getElementById("Marks").value;

    var message = "";

    if (id.length > 5) {
        message += "ID number should not exceed 5 digits.\n";
    }

    if (id == "" || firstName == "" || lastName == "" || address == "" || dob == "" || fatherName == ""
        || motherName == "" || mobile == "" || marks == "") {
        message += "All the fields are compulsory.\n";
    }

    message += checkIfNumber(id);
    message += checkIfNumber(marks);
    message += checkIfAlphabet(firstName);
    message += checkIfAlphabet(lastName);
    message += checkDob(dob);
    message += checkIfAlphabet(fatherName);
    message += checkIfAlphabet(motherName);
    message += checkPhone(mobile);
    message += checkMarks(marks);
   

    if (message.length > 0) {
        alert(message);
        return false;
    }

    return true;
}

function checkIfAlphabet(input) {
    const regex = /^[a-zA-Z ]*$/;
    if (!regex.test(input)) {
        return "Only alphabets and spaces are allowed for " + input+".\n";
    }
    return "";
}

function checkPhone(input) {
    const regex = /^[0-9]{10}$/;
    if (!regex.test(input)) {
        return "Mobile number should contain only 10 digits.\n";
    }
    return "";
}

function checkMarks(input) {
    
    if (input <200 || input >500) {
        return "Marks must inbetween 200 to 500\n";
    }
    return "";
}
function checkDob(input) {
    var year = input.slice(0,4);
    var currYear = new Date();
    console.log(input)
    if ((currYear.getFullYear() - year )<17) {
        return "Age must be greater than or equal to 17 \n";
    }
    return "";
}


function validateIndex() {
    var id, firstname;
    var id = document.getElementById("Id").value;
    var firstName = document.getElementById("FirstName").value;

    var message = "";
    if (id.length > 5) {
        message += "ID number should not exceed 5 digits.\n";
    }
    message += checkIfNumber(id);
    message += checkIfAlphabet(firstName);
    if (message.length > 0) {
        alert(message);
        return false;
    }
    return true;
}