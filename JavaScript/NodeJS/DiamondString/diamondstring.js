function diamond(n) {
	if (n <= 0 || n & 1 == 0) return null; 
	return [...Array(n).keys()].map( (k) => " ".repeat(Math.abs((n-1)/2 - k)) + "*".repeat(n - Math.abs(2*((n-1)/2 - k))) + "\n").join("");
}

console.log(diamond(5));
