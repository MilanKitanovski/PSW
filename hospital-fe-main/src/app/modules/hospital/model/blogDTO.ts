import {DateRange} from "./date-range.model";

enum BlogTheme{
  Medicine, Health, Actual
}

export class BlogDTO {
  textBlog: string = "";
  theme!: BlogTheme;


  public constructor(TextBlog: string = "") {
    this.textBlog = TextBlog;
  }
}
