function solution(roman) {
	let numerals = {"I": (acc) => { return acc + ((acc >= 5) ? -1 : 1)},
									"V": (acc) => { return acc + 5 },
									"X": (acc) => { return acc + ((acc >= 50) ? -10 : 10) },
									"L": (acc) => { return acc + 50 },
									"C": (acc) => { return acc + ((acc >= 500) ? -100 : 100) },
									"D": (acc) => { return acc + 500 },
									"M": (acc) => { return acc + 1000} };
	return [...roman].reverse().reduce( (acc, n) => numerals[n](acc) , 0);
}

console.log(solution("MCMXC"));
