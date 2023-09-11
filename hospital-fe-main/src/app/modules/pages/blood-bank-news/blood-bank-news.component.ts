import { Component, OnInit } from '@angular/core';
import {BloodBankNewsService} from "../../hospital/services/blood-bank-news.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-blood-bank-news',
  templateUrl: './blood-bank-news.component.html',
  styleUrls: ['./blood-bank-news.component.css']
})
export class BloodBankNewsComponent implements OnInit {
  displayedColumns: string[] = ['bloodBankNews'];
  dataSource : any[] = [];
  selectedRow: any | null = null;
  constructor(private bloodBankNewsService: BloodBankNewsService,
              private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.getNews();
  }

  getNews() {
    this.bloodBankNewsService.GetAllNews().subscribe((data) => {
      this.dataSource = data;
    });
  }

  archive(dto : any){
    this.bloodBankNewsService.ArchiveNews(dto.id).subscribe((data ) => {
      this.getNews();
      this.toastr.success("News archived", "News");
    });
  }

  publish(dto : any){
    console.log("1")
    this.bloodBankNewsService.PublishNews(dto.id).subscribe((data ) => {
      this.getNews();
      console.log("2")
      this.toastr.success("News published", "News");
    });
  }

  selectRow(row: any) {
    this.selectedRow = row;
  }
}
