import {animate, state, style, transition, trigger} from '@angular/animations';

export const fadeInAnimation = trigger('fadeInAnimation', [
    state('void', style({opacity: 0})),
    transition('* <=> void', animate(200))
]);
