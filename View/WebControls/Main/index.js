function makeCounter() {
    let count = 0;

    document.getElementById("counter").innerText = $`Counter : ${count}`;
    
    return function() {
        return count++;
    }    
}