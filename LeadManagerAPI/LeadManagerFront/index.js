// Toggle between the tabs
function showInvited() {
    document.getElementById("invited").classList.remove("hidden");
    document.getElementById("accepted").classList.add("hidden");
    document.getElementById("invitedTab").classList.add("active");
    document.getElementById("acceptedTab").classList.remove("active");
}

function showAccepted() {
    document.getElementById("invited").classList.add("hidden");
    document.getElementById("accepted").classList.remove("hidden");
    document.getElementById("invitedTab").classList.remove("active");
    document.getElementById("acceptedTab").classList.add("active");
}

// Functions to handle accepting and declining leads
function acceptLead(name, price) {
    if (price > 500) {
        price = price * 0.9; // Apply 10% discount
    }
    console.log(`${name} accepted at price $${price}. Sending notification...`);
    alert(`${name} has been accepted. Price: $${price}`);
}

function declineLead(name) {
    console.log(`${name} declined.`);
    alert(`${name} has been declined.`);
}
