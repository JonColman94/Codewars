function wave(str) {
	var res = [];
	[...str].forEach( (c, idx) => { if (c != ' ') { res.push(str.slice(0, idx) + c.toUpperCase() + str.slice(idx+1)); } } );
	return res;
}
				
console.log(wave("two words"));

