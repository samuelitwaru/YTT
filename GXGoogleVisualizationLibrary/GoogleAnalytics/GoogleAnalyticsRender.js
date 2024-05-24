function GoogleAnalytics() {
	this.Dimensions = null;

	this.GetDimensions = function () {
		return this.Dimensions;
	};

	this.SetDimensions = function (dimensions) {
		this.Dimensions = dimensions;
	};

	this.show = function () {
		///UserCodeRegionStart:[show] (do not remove this comment.)

		//<!-- Global site tag (gtag.js) - Google Analytics -->
		var script = document.createElement('script');
		var GAKey = this.Code;
		script.src = `https://www.googletagmanager.com/gtag/js?id=${GAKey}`;
		script.async = true;

		var afterLoadfnc = () => {
			window.dataLayer = window.dataLayer || [];
			function gtag() { dataLayer.push(arguments); }
			window.gtag = gtag;
			if (gx.ONAFTERGALOAD_EVT) {
				gx.fx.obs.notify(gx.ONAFTERGALOAD_EVT);
			}
			gtag('js', new Date());
			gtag('config', GAKey);

			var cookieDomain = (this.DomainName != '<yourDomainNameHere>') ? this.DomainName : 'auto';
			var gaOpts = {
				'trackingId': this.Code,
				'cookieDomain': cookieDomain,
				'allowLinker': this.AllowLinker
			};

			gtag('config', GAKey, gaOpts);
			gtag('set', { 'dimension1': gx.gxVersion });

			// Send custom dimensions
			gtag('event', 'page_view', this.Dimensions || {});

			gx.evt.attach(window, 'error', (messageOrEvent, source, lineno, colno, error) => {
				if (typeof (messageOrEvent) !== 'string' && messageOrEvent.error) {
					msg = messageOrEvent.error.message + ' - ' + messageOrEvent.error.stack || ''
				}
				gtag('event', 'exception', {
					'exDescription': msg,
					'eXFatal': true
				});

				return false;
			})
		}
		script.addEventListener('load', afterLoadfnc.bind(this));
		document.head.appendChild(script);
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)

	///UserCodeRegionEnd: (do not remove this comment.):
}