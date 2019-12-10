function findUniq(arr) {
	var counts = {}
	arr.forEach( (c) => { if (!counts[c]) counts[c] = 1; else counts[c]++ } );
	
	return Number(Object.keys(counts).find( (n) => counts[n] == 1));
}


console.log(findUniq([3,10,3,3,3,3]));
