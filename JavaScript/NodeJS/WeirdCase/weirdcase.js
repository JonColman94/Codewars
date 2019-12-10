function toWeirdCase(string) {
	let func_hash = { 0: (c) => c.toUpperCase(), 1: (c) => c.toLowerCase() };
	let str_split = string.split(" ");
	return str_split.map( (s) => [...s].reduce( (res, c, idx) => res + func_hash[idx & 1](c) , "")).join(" ");
}

console.log(toWeirdCase("This is a test"));
