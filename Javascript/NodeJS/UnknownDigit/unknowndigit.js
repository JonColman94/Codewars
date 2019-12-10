function solveExpression(exp) {
	for (let n of getAvailableDigits(exp))
	{
		if (Function('"user strict"; return (' + sanitiseExpression(exp).replace(/\?/g, n) + ');')()) return n;
	}
	return -1;
}

function sanitiseExpression(exp) {
	let res = exp.replace('=', '==');
	res = res.replace(/((\+\-)|(\-\+)|(\-(\-{2})*)){1,1}(((\+\-)|(\-\+)|(\-(\-{2})*)){2})*/g, '-');
	res = res.replace(/(((\-{2})|(\++)){1,1})(((\-{2})|(\++)){2})*/g, '+');
	res = res.replace(/\*\+/g, '*');
	res = res.replace(/\=\+/g, '=');
	return res;
}

function getAvailableDigits(exp) {
	let set = new Set([...Array(10).keys()]);
	let digits = exp.match(/\d/g);
	digits.forEach( (d) => set.delete(parseInt(d)));
	if (exp.match(/[\+\-\*\=]\?\?/g)) set.delete(0);
	return set;
}

console.log(solveExpression('?*11=??'));
console.log(solveExpression('1+1=?'))
