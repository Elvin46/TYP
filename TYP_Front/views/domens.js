import { html, VLitElement, classMap } from "../lit.js"

export class VDomens extends VLitElement {
	static properties = {
		ad: {},
		kod: {},
		kredit: {},
		kurs: {},
		qrup: {},
		tcount: {},
		muhazire: {},
		mesqele: {},
		lab: {},
		meslehet: {},
		exam: {},
		muhazire2: {},
		mesqele2: {},
		lab2: {},
		meslehet2: {},
		exam2: {},
		prehber: {},
		elmitecrube: {},
		bishi: {},
		doct: {},
		yekun: {},
	}
	fresh(){
		this.ad = ""
		this.kod = ""
		this.kredit = ""
		this.kurs = ""
		this.qrup = 0
		this.tcount = ""


		this.muhazire = 0
		this.mesqele = 0
		this.lab = 0
		this.meslehet = 0
		this.exam = 0
		this.muhazire2 = 0
		this.mesqele2 = 0
		this.lab2 = 0
		this.meslehet2 = 0
		this.exam2 = 0		
		this.prehber = ""
		this.elmitecrube = ""
		this.bishi = ""
		this.doct = ""

	}
	constructor() {
		super()
		this.fresh()
	}
	render() {
		this.yekun = +this.muhazire +
							+this.mesqele +
							+this.lab +
							+this.meslehet +
							+this.exam +
							+this.muhazire2 +
							+this.mesqele2 +
							+this.lab2 +
							+this.meslehet2 +
							+this.exam2

		return html`
		<table class="table typ">
		<thead class="thead-dark">
			<tr>
				<th scope="col" class="verticalTableHeader row">Fakültələr</th>
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
				<td c >Maliyyə və mühasibat</td>
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
				<td c>Beynəlxalq iqtisadiyyat məktəbi</td>
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
				<td c>İqtisadiyyat</td>
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
				<td c>Rus iqtisad məktəbi</td>
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
				<td c>Rəqəmsal iqtisadiyyat </td>
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
				<td c>Mühəndislik</td>
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
				<td c>Biznes və menecment</td>
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
				<td c>Türk dünyası iqtisad</td>
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
				<td c>Distant, qiyabi və əlavə təhsil mərkəzi</td>
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
				<td c>SABAH mərkəzi</td>
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
				<td c>Magistratura mərkəzi</td>
				<td c>1474</td>
				<td c>1524</td>
				<td c></td>
				<td c>62</td>
				<td c>217</td>
				<td c>3277</td>
				<td c>480</td>
				<td c>510</td>
				<td c></td>
				<td c>23</td>
				<td c>122</td>
				<td c>60</td>
				<td c></td>
				<td c>180</td>
				<td c></td>
				<td c>3480</td>
				<td c></td>
				<td c>4855</td>
				<td c class="bold-table">8132</td>
			</tr>
			<tr>
				<td c>Beynəlxalq magistratura və doktorantura mərkəzi</td>
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
				<td c>360</td>
				<td c></td>
				<td c>360</td>
				<td c class="bold-table">360</td>
			</tr>
			<tr>
				<td c>UNEC Biznes məktəbi (MBA)</td>
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
				<td c>40</td>
				<td c></td>
				<td c>40</td>
				<td c class="bold-table">40</td>
			</tr>
			<tr>
				<td c>Doktorantura</td>
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
				<td c>250</td>
				<td c>250</td>
				<td c class="bold-table">250</td>
			</tr>
			<tr>
				<td c>UNEC Dizayn məktəbi</td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c></td>
				<td c>0</td>
				<td c>90</td>
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
				<td c>195</td>
				<td c class="bold-table">195</td>
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
		`
	}
}

VDomens.tag = "v-domens"
