import { html, VLitElement, classMap } from "../lit.js"

import "./tabs.js"
import "./login.js"

window.atV = "tabs"

export class VMain extends VLitElement {
	constructor(){
		super()
		window.update = (...arg) => this.update(...arg)
	}
	render() {
		return html`
		<div class="header">
			<img class="nazirlik" src="./img/elm ve etehsil nazirliyi.png" alt="">
			<p>Tədris Yükünün Paylanması Avtomatlasdirilmis Informasiya Sistemi</p>
			<img class="unec" src="./img/unec fil fit.png" alt="">
		</div>
		<!-- <img src="./img/header.png" alt="" class=${classMap({ 
				header:true,
				semiOpaceHeader: window.atV == "login"
			})}> -->
		${window.atV == "tabs" ? html`<v-tabs></v-tabs>` : ""}
		${window.atV == "login" ? html`<v-login></v-login>` : ""}
		`
	}
	getFenns(ixts){
		console.log('got fenns')
		console.log(getSubjects(ixts))
		fennler = getSubjects(ixts)
		this.requestUpdate()
	}
}


VMain.tag = "v-main"

window.main = document.createElement("v-main")
window.updateMain = ()=>main.requestUpdate()
window.goTo = route => {
	window.atV = route
	main.requestUpdate()
}

document.body.appendChild(window.main)