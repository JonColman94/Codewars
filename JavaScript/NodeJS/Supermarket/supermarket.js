function queueTime(customers, n) {
	var tills = Array.from({length: n}, (v, i) => 0);
	customers.forEach( (c) => {
		min_index = 0;
		for (index = 1; index < tills.length; index++) {
			if (tills[index] < tills[min_index]) min_index = index
			if (tills[min_index] == 0) break;
		}
		tills[min_index] += c
		}
	);
	return Math.max.apply(null, tills);
}

console.log(queueTime([2,2,3,3,4,4], 2));
