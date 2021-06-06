import {Injectable, Renderer2, RendererFactory2} from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AppThemeService {
    private _renderer: Renderer2;
    private _colorScheme: string;
    private readonly _colorSchemePrefix: string = 'color-scheme-';

    constructor(private readonly rendererFactory: RendererFactory2) {
        this._renderer = this.rendererFactory.createRenderer(null, null);
    }

    private detectPreferredTheme(): void {
        if (window.matchMedia('(prefers-color-scheme)').media !== 'not all') {
            this._colorScheme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
            return;
        }
        this._colorScheme = 'dark';
    }

    setColorScheme(scheme: string): void {
        this._colorScheme = scheme;
        localStorage.setItem('prefers-color', scheme);
    }

    getColorScheme(): void {
        if (localStorage.getItem('prefers-color') === 'dark' || localStorage.getItem('prefers-color') === 'light') {
            this._colorScheme = localStorage.getItem('prefers-color');
            return;
        }
        this.detectPreferredTheme();
    }

    load(): void {
        this.getColorScheme();
        this._renderer.addClass(document.body, this._colorSchemePrefix + this._colorScheme);
    }

    update(scheme: string): void {
        this.setColorScheme(scheme);
        this._renderer.removeClass(document.body, this._colorSchemePrefix + (this._colorScheme === 'dark' ? 'light' : 'dark'));
        this._renderer.addClass(document.body, this._colorSchemePrefix + scheme);
    }

    currentActive(): string {
        return this._colorScheme;
    }
}
