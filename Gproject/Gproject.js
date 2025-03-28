document.addEventListener('DOMContentLoaded', function () {
    console.log("DOM volledig geladen en geparseerd");

    document.getElementById("load-personen").addEventListener("click", function () {
        fetch("http://localhost:5265/api/Datapersonen")
            .then(response => response.json())
            .then(data => {
                console.log(data)
                const PersonenList = document.getElementById("personen-list");
                PersonenList.innerHTML = "";
                data.forEach(personen => {
                    console.log(personen.Voornaam);
                    const div = document.createElement("div");
                    div.className = "personen";
                    div.innerHTML = `<h2>${personen.voornaam}</h2><h2>${personen.achternaam}</h2><h2>${personen.leeftijd}<p>${personen.locatieID}</p>`;
                    PersonenList.appendChild(div);
                });
            })
            .catch(error => console.error("Fout bij het ophalen van gegevens:", error));
    })

    document.getElementById("create-account").addEventListener("click", function () {
        const Voornaam = document.getElementById("new-personen-Voornaam").value;
        const Achternaam = document.getElementById("new-personen-Achternaam").value;
        const Leeftijd = document.getElementById("new-personen-Leeftijd").value;
        const LocatieID = document.getElementById("new-personen-LocatieID").value;
        const ID = 5;
        fetch("http://localhost:5265/api/Datapersonen", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ Voornaam, Achternaam, Leeftijd, LocatieID})
        })
            .catch(error => console.error("Fout bij het toevoegen van gegevens:",
                error));
    });
    
    
    document.getElementById("delete-account").addEventListener("click", function () {
        const personID = document.getElementById("delete-personen-ID").value;
        fetch(`http://localhost:5265/api/Datapersonen/${personID}`, {
            method: "DELETE"
        })
            .then(response => {
                if (response.ok) {
                    alert("Persoon succesvol verwijderd!");
                    document.getElementById("delete-personen-ID").value = ""; // Clear input
                    document.getElementById("delete-form").style.display = "none"; // Hide form
                } else {
                    alert("Er is iets misgegaan bij het verwijderen.");
                }
            })
            .catch(error => console.error("Fout bij het verwijderen van gegevens:", error));
    });
})