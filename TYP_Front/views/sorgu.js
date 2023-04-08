import { getTeachers } from "../api.js"
import { html, VLitElement, classMap } from "../lit.js"

export class  VSorgu extends VLitElement {
	constructor(){
		super();
		var teachers;
		var content;
		getTeachers().then(data=>{
			content = data.teachers.map((teacher)=>
				html`
				<tr>
					<td c>${teacher.name}</td>
					<td c>${teacher.surname}</td>
					<td c>${teacher.jobType}</td>
					<td c>${teacher.scientificName}</td>
					<td>${teacher.department}</td>
					<td c>${teacher.sex}</td>
					<td c>${teacher.birthDate}</td>
					<td>${teacher.scientificDegree}</td>
					<td><button @click=${
						async e => {
							window.teacherId = teacher.id
							let res = await fetch(`https://localhost:44384/api/Distribution/${teacher.id}`)
							let js = await res.json()

							
							var finalList = [
								...js.predmetGroups.filter(predmet=>predmet.orderBy==0).map(_=>[_]),
								...js.orderBys.map(order=>js.predmetGroups.filter(predmet=>predmet.orderBy==order))
							]
							console.log(finalList);
							let sorguContent = finalList.map(row=>
								html`
							<tr>
							<td>
								${row.map(cell=>html`${cell.code}<br>`)}
							</td>
							<td>
								${row.map(cell=>html`<button @click=${async e=>{
									await fetch("https://localhost:44384/api/Distribution",{
										method: "POST",
										body: JSON.stringify({
											TeacherId: window.teacherId,
											PredmetGroupId: cell.id
										}),
										headers:{
											"Content-type":"application/json;charset=UTF-8",
										}
									}).then(async res=>{
										 console.log(res.status)
										//  ;[...this.querySelectorAll("button.disabled")].map(b=>b.classList.remove("disabled"))
										 if(res.status>=200&&res.status<=299){
											console.log
											e.target.classList.add("cyanish")
										 }
										 else{
											e.target.disabled = true
											e.target.classList.add("disabled")
											e.target.parentElement.insertAdjacentHTML("beforeend",`<p style="color: red">${(await res.json()).message}</p>`)
										 }
										})
									.catch(error=>console.log(error));
									this.requestUpdate()
								}} class=${window.teacherId == cell.teacherId ? "cyanish" : cell.teacherId == 0 ? "" : "redish"}>Choosen</button>${cell.predmetName}<br>`)}
							</td>
							<td c>${row[0].group}</td>
							<td c>${row[0].course}</td>
							<td>${row[0].profession}</td>
							<td c>${row[0].sector}</td>
							<td c>${row[0].credit}</td>
							<td c>${row[0].generalHours}</td>
							<td c>${row[0].auditoryHours}</td>
							<td c>${row[0].session}</td>
							</tr>
							`)
							
							this.tabble =
								html`
								<button style="padding: 10px 20px;border-radius: 5px;border:1px solid #999;"><a style="text-decoration: none; color: black;" href="../teachers.html?id=8">Tesdiqle</a></button>
								<table class="table">
									<thead class="thead-dark">
										<tr>
									
											<th scope="col">Code</th>
											<th scope="col">Predmet</th>
											<th scope="col">Group</th>
											<th scope="col">Course</th>
											<th scope="col">Profession</th>
											<th scope="col">Sector</th>
											<th scope="col">Credit</th>
											<th scope="col">General Hours</th>
											<th scope="col">Auditory Hourse</th>
											<th scope="col">Session</th>
										</tr>
									</thead>
									<tbody>
										${sorguContent}
									</tbody>
								</table>
								`;						
							this.requestUpdate()
						}
					}>Sorgu</button></td>
				</tr>`
			);
			this.requestUpdate()

			// console.log(content);
			this.content = content
			this.tabble = html`		<table class="table">
			<thead class="thead-dark">
				<tr>
			
					<th scope="col">Name</th>
					<th scope="col">Surname</th>
					<th scope="col">Job Type</th>
					<th scope="col">Scientific Name</th>
					<th scope="col">Department</th>
					<th scope="col">Sex</th>
					<th scope="col">Birthdate</th>
					<th scope="col">Scientific Degree</th>
					<th scope="col">Sorgu</th>
				</tr>
			</thead>
			<tbody>
				${this.content}
			</tbody>
			</table>
	`
		});
	}
	render(){
		return html`
		<!-- <div class="domenCols"> -->
		<!-- 	<div class="docol"> -->
		<!-- 		<v-dils></v-dils> -->
		<!-- 	</div> -->
		<!-- 	<div class="docol tabCol"> -->
		<!-- 		<label for="sertfs">Sertifikatlar</label> <br> -->
		<!-- 		<textarea style="padding: 7px; width: 250px"></textarea> -->
		<!-- 	</div> -->
		<!-- </div> -->	
		${this.tabble}
		`
	}
}

VSorgu.tag = 'v-sorgu'
