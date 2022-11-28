const cacheName = 'Autovyn';
const staticAssets = [
    './',
    './mobile/index.aspx',
    './mobile/index.js',
    './mobile/assets/img/favicon.png',
    './mobile/assets/css/style.css',
    './mobile/assets/js/lib/jquery-3.4.1.min.js',
    './mobile/assets/js/lib/bootstrap.bundle.min.js',
    './mobile/assets/js/plugins/splide/splide.min.js',
    './mobile/assets/js/base.js',
    './mobile/assets/js/base.js',
];

self.addEventListener('install', async e => {
    const cache = await caches.open(cacheName);
    await cache.addAll(staticAssets);
    return self.skipWaiting();
});

self.addEventListener('activate', e => {
    self.clients.claim();
});

self.addEventListener('fetch', async e => {
    const req = e.request;
    const url = new URL(req.url);

    if (url.origin === location.origin) {
        e.respondWith(cacheFirst(req));
    } else {
        e.respondWith(networkAndCache(req));
    }
});

async function cacheFirst(req) {
    const cache = await caches.open(cacheName);
    const cached = await cache.match(req);
    return cached || fetch(req);
}

async function networkAndCache(req) {
    const cache = await caches.open(cacheName);
    try {
        const fresh = await fetch(req);
        await cache.put(req, fresh.clone());
        return fresh;
    } catch (e) {
        const cached = await cache.match(req);
        return cached;
    }
}