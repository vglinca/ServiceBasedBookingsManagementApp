import { Component } from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {fadeAnimation} from './animations/fade.animation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [fadeAnimation]
})
export class AppComponent {
  title = 'OnlineBookingAggregatorApp';

  getRouterOutletState = (outlet: RouterOutlet) => outlet.isActivated ? outlet.activatedRoute : '';
}
