function tickets(peopleInLine) {
	let [c25, c50] = [0,0]
	for(let p of peopleInLine) {
		if(p==25) c25++;
		if(p==50) {c50++; c25--}
		if(p==100) {c25--; c50 > 0 ? c50-- : c25 -=2;}
		if(c25<0 || c50<0) return 'NO';
	}
	return 'YES';
}

console.log(tickets([25, 100]));
