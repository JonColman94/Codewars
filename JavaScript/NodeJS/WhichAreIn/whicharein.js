function inArray(array1, array2) {
	return [...new Set(array1)].filter( s1 => array2.some( s2 => s2.includes(s1) )).sort();
}

console.log(inArray(["xyz","live","strong"],["lively", "alive", "harp", "sharp", "armstrong"]));
