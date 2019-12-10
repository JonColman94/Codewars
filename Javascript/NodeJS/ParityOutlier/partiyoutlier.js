function findOutlier(integers){
	sum = integers.reduce( (acc, x, idx) => acc + ((x & 1 == 1) ? (idx+1) : 0), 0);
	return integers[((sum > integers.length) ? (integers.length)*(integers.length+1)/2 - sum : sum)-1];
}

console.log(findOutlier([2,6,98,57,24,12,80,1026]));
