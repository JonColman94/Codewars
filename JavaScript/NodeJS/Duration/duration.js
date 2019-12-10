function formatDuration (seconds) {
	let durations_from_seconds = { 
					"years" : (s) => { return s/(60*60*24*365)}, 
					"days" : (s) => { return s/(60*60*24) },
					"hours" : (s) => { return s/(60*60) },
					"minutes" : (s) => { return s/60 },
					"seconds" : (s) => { return s } }
	let duration_split = Object.keys(durations_from_seconds);
	return duration_split;
}

console.log(formatDuration(3662));
