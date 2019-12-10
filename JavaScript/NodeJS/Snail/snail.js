function snail(array) {
	var n = array.length;
	if (n == 0) return [[]];
	if (n == 1) return (array[0] == []) ? [[]] : [array[0][0]];
	let remainder = array.copyWithin();
	let [snail_head, snail_tail] = [remainder.shift(), remainder.pop().reverse()];
	n = remainder.length;
	for (let idx = 0; idx < n; idx++) {
		snail_head.push(remainder[idx].pop());
		snail_tail.push(remainder[(n-1-idx)].shift());
	}
	console.log(remainder);
	return snail_head.concat(snail_tail).concat(snail(remainder));
}

console.log(snail([[1,2,3], [4,5,6], [7,8,9]]));
