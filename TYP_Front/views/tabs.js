import { html, VLitElement, classMap } from "../lit.js"
import { getFaculties, getTeachers, getPane2Ixtisases } from "../api.js"
// import {subjects} from "../dummyData.js"

import "./tabber.js"
import "./domens.js"
import "./teacher.js"
import "./dils.js"
import "./sorgu.js"

let pane2 = html``
let pane1 = html``

let selectedPane0 = ""
let selectedPane1 = ""
let selectedPane2 = ""

let yuk = null

export class VTabs extends VLitElement {
	static properties = {
		// minimized: {},
	}
	constructor() {
		super()
		// this.minimized = false
	}
	pane1teachers(e) {
		selectedPane0 = "teachers"
		this.requestUpdate()
	}
	// changeMinimize(e) {
		// this.minimized = !this.minimized
	// }
	render() {
		return html`
			<div class="tabCol co1">
				<button
					class=${classMap({
						tab: true,
						selected: selectedPane0 == "faculties",
						highTab: true,
					})}
					@click=${e=>{
						selectedPane0 = "faculties"
						selectedPane1 = ""
						selectedPane2 = ""
						this.requestUpdate()
					}}
				>
					Tədris yükünün daxil <br />
					olduğu fakultələr
				</button>
				<button
					class=${classMap({
						tab: true,
						selected: selectedPane0 == "teachers",
					})}
					@click=${e=>{
						selectedPane0 = "teachers"
						selectedPane1 = ""
						selectedPane2 = ""
						this.requestUpdate()
					}}
				>
					Müəllimlər
				</button>
				<button class="tab" 
				class=${classMap({
						tab: true,
						selected: selectedPane0 == "meyars",
					})}
				@click=${e=>{
					selectedPane0 = "meyars"
					selectedPane1 = ""
					selectedPane2 = ""
					this.requestUpdate()
				}}>Sorğu (Meyarlar)</button>
				<button
					class=${classMap({
						tab: true,
						selected: selectedPane0 == "outDepartment",
					})}
					@click=${e=>{
						selectedPane0 = "outDepartment"
						selectedPane1 = ""
						selectedPane2 = ""
						this.requestUpdate()
					}}
				>Kafedradan çıxan yük
				</button>
				<!-- <button 
				class = ${
					classMap({	
						tab: true,
						selected: selectedPane0 == "sorgu"})
				}
				@click = ${
					e=>{
						selectedPane0 = "sorgu"
						this.requestUpdate()
					}
				}>Sorğu</button> -->
				<button
					class=${classMap({ tab: true })}
					@click=${e => window.goTo("login")}
				>
					Çıxış
				</button>
			</div>

			<div
				class=${classMap({
					tabCol: true,
					// hidden: !(selectedPane0 == "faculties" )
					// hidden: this.minimized || !pane1.length,
					// hidden: selectedPane0 != "faculties" 
				})}
			>
			${
				selectedPane0 == "faculties" ? 
				html`<v-domens></v-domens>` :
				selectedPane0 == "ixtisases" ? 
				html`<v-domens></v-domens>` : 
				selectedPane0 == "outDepartment" 
				? html`
				<table class="table typ">
		<thead class="thead-dark">
			<tr>
				<th scope="col" class="verticalTableHeader row">Kafedralar</th>
				<th scope="col" class="verticalTableHeader">Mühazirə</th>
				<th scope="col" class="verticalTableHeader">Məşğələ</th>
				<th scope="col" class="verticalTableHeader">Laboratoriya</th>
				<th scope="col" class="verticalTableHeader">Məsləhət</th>
				<th scope="col" class="verticalTableHeader">Imtahan</th>
				<th scope="col" class="verticalTableHeader">I sem-cəmi</th>
				<th scope="col" class="verticalTableHeader">Mühazirə</th>
				<th scope="col" class="verticalTableHeader">Məşğələ</th>
				<th scope="col" class="verticalTableHeader">Laboratoriya</th>
				<th scope="col" class="verticalTableHeader">Məsləhət</th>
				<th scope="col" class="verticalTableHeader">Imtahan</th>
				<th scope="col" class="verticalTableHeader">Pr Rehber</th>
				<th scope="col" class="verticalTableHeader">Istehsalat təcrübəsi</th>
				<th scope="col" class="verticalTableHeader">EPedT, ETədT, TKI, TA</th>
				<th scope="col" class="verticalTableHeader">Buraxılış işi</th>
				<th scope="col" class="verticalTableHeader">Magist dissert</th>
				<th scope="col" class="verticalTableHeader">Doktorantura</th>
				<th scope="col" class="verticalTableHeader">II sem-cəmi</th>
				<th scope="col" class="bold-table verticalTableHeader">Yekun</th>
			</tr>
		</thead>
		<tbody>
			<tr>
				<td c >Ətraf mühitin mühafizəsi və iqtisadiyyatı</td>
				<td c>210</td>
				<td c>630</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>840</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c class="bold-table">840</td>
			</tr>
			<tr>
				<td c>Riyaziyyat və statistika</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>0</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c class="bold-table">0</td>
			</tr>
			<tr>
				<td c>Biznesin idarə edilməsi</td>
				<td c>240</td>
				<td c>450</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>690</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c class="bold-table">690</td>
			</tr>	
			<tr>
				<td c>İqtsadiyyat_RUS</td>
				<td c>210</td>
				<td c>375</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>585</td>
				<td c>150</td>
				<td c>105</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>255</td>
				<td c class="bold-table">840</td>
			</tr>	
			<tr>
				<td c>Rəqəmsal texnologiyalar və tətbiqi informatka  </td>
				<td c>2490</td>
				<td c>3375</td>
				<td c>120</td>
				<td c></td>
				<td c></td>
				<td c>5985</td>
				<td c>2400</td>
				<td c>3360</td>
				<td c>120</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>880</td>
				<td c></td>
				<td c>300</td>
				<td c></td>
				<td c></td>
				<td c>7060</td>
				<td c class="bold-table">13045</td>
			</tr>
			<tr>
				<td c>Mühəndislik və tətbiqi elmlər </td>
				<td c>270</td>
				<td c>345</td>
				<td c>30</td>
				<td c></td>
				<td c></td>
				<td c>645</td>
				<td c>75</td>
				<td c>120</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>195</td>
				<td c class="bold-table">840</td>
			</tr>
			<tr>
				<td c>Humanitar fənlər</td>
				<td c>330</td>
				<td c>690</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>1020</td>
				<td c>30</td>
				<td c>60</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>90</td>
				<td c class="bold-table">1110</td>
			</tr>
			<tr>
				<td c>Azərbaycan dili</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>0</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c class="bold-table">0</td>
			</tr>
			<tr>
				<td c>Xarici dil</td>
				<td c>590</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>590</td>
				<td c>362</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>280</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>642</td>
				<td c class="bold-table">1232</td>
			</tr>
			<tr>
				<td c>İqtsadiyyat_AZ</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>0</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c class="bold-table">0</td>
			</tr>
			<tr class="bold-table">
				<td class="heading" c>CƏMİ</td>
				<td c>5814</td>
				<td c>7389</td>
				<td c>150</td>
				<td c>62</td>
				<td c>217</td>
				<td c>13632</td>
				<td c>3587</td>
				<td c>4260</td>
				<td c>120</td>
				<td c>23</td>
				<td c>122</td>
				<td c>60</td>
				<td c>1160</td>
				<td c>180</td>
				<td c>300</td>
				<td c>3880</td>
				<td c>250</td>
				<td c>13942</td>
				<td c class="bold-table">27574</td>
			</tr>
		</tbody>
	</table>
				` :html``

			}
			</div>

			<div
				class=${classMap({
					tabCol: true,
					fenn: true,
					// hidden: this.minimized || !pane2.length,
				})}
			>
				${
					selectedPane0 == "teachers" ? 
					html`<v-teacher></v-teacher>` : 
					selectedPane0 == "faculties" && selectedPane1 ? 
					html`<v-domens .listLink=${"./pdfs/Mühəndislik_2022-2023.pdf"}></v-domens>` : 
					selectedPane0 == "meyars" ? 
					html`<v-sorgu></v-sorgu>` :
					// selectedPane0 == "sorgu" ?
					// html`<v-sorgu></v-sorgu>` :
					html``
				}
			</div>
			<div
				class=${classMap({
					tabCol: true,
					yukContent: true,
					hidden: !(selectedPane2 && selectedPane1),
					// fenn: true,
					// hidden: this.minimized,
				})}
			>
				<form>
					<label>${selectedPane2}</label> <br />
					<br />
					<label for="hours">Dərs Saatları</label> <br />
					<input type="number" name="hours" id="hours" value="30" min="1" />
					<br />
					<br />
					<label for="kredit">Krediti</label> <br />
					<input type="number" name="kredit" id="kredit" value="1" min="1" />
					<br />
					<br />
					<label for="tform">Tədris Forması</label> <br />
					<select name="tform" id="tform">
						<option value="eyani">Əyani</option>
						<option value="qiyabi">Qiyabi</option>
					</select>
					<br />
					<br />
					<label for="startDate">Başlanğıc Tarixi</label> <br />
					<input
						type="date"
						id="startDate"
						name="startDate"
						value="2020-07-22"
						min="1930-01-01"
						max="2025-12-31"
					/>
					<br />
					<br />
					<label for="muallim">Müəllim</label> <br />
					<input
						type="text"
						name="muallim"
						id="muallim"
						placeholder="Müəllimin Adı"
					/>
					<br />

					<br />
					<button type="submit" class="tab submitButton">Göndər</button>
				</form>
			</div>
		`
	}
	// getYuk(fenn) {
		// selectedPane2 = fenn
		// yuk = null
		// yuk = { someProp: "mono" }
		// this.requestUpdate()
	// }
}

VTabs.tag = "v-tabs"
